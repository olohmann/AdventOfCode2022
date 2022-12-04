namespace Advent
open System.IO

module ElvishRockPaperScissorsStrategy =
    type Action =  Rock = 1 | Paper = 2 | Scissors = 3
    type Score =  Lost = 0 | Draw = 3 | Won = 6

    type Match =
        { 
            P1: Action;
            P2: Action
        }

    type ScoredMatch = int   

    let fileToLines (inputFilePath : string) =
        File.ReadAllLines(inputFilePath)

    let parsePlayerOne(x: char) : Action =
        if x = 'A' then Action.Rock 
        elif x = 'B' then Action.Paper
        elif x = 'C' then Action.Scissors
        else raise (System.ArgumentException("Unexpected character."))

    let parsePlayerTwo(x: char) : Action =
        if x = 'X' then Action.Rock 
        elif x = 'Y' then Action.Paper
        elif x = 'Z' then Action.Scissors
        else raise (System.ArgumentException("Unexpected character."))
        
    let parseMatch(matchStr: string) : Match =
         { 
            P1 = parsePlayerOne (matchStr[0]);
            P2 = parsePlayerTwo (matchStr[2]) 
         }

    let scoreMatch(m : Match) : ScoredMatch = 
        match m with
        | {P1 = Action.Rock; P2 = Action.Rock} -> (int Action.Rock) + (int Score.Draw)
        | {P1 = Action.Paper; P2 = Action.Rock} -> (int Action.Rock) + (int Score.Lost)
        | {P1 = Action.Scissors; P2 = Action.Rock} -> (int Action.Rock) + (int Score.Won)

        | {P1 = Action.Rock; P2 = Action.Paper} -> (int Action.Paper) + (int Score.Won)
        | {P1 = Action.Paper; P2 = Action.Paper} -> (int Action.Paper) + (int Score.Draw)
        | {P1 = Action.Scissors; P2 = Action.Paper} -> (int Action.Paper) + (int Score.Lost)

        | {P1 = Action.Rock; P2 = Action.Scissors} -> (int Action.Scissors) + (int Score.Lost)
        | {P1 = Action.Paper; P2 = Action.Scissors} -> (int Action.Scissors) + (int Score.Won)
        | {P1 = Action.Scissors; P2 = Action.Scissors} -> (int Action.Scissors) + (int Score.Draw)

        | _ -> raise(System.ArgumentException("Unexpected match.")) 

        
    let parseToMatches (matches: string seq) : Match seq = 
        matches 
        |> Seq.map(fun x -> parseMatch x)

    let scoreMatches(matches: Match seq) : ScoredMatch seq = 
        matches
        |> Seq.map(scoreMatch)
