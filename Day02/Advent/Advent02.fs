namespace Advent
open System.IO

module ElvishRockPaperScissorsStrategyDecrypted =
    type Action =  Rock = 1 | Paper = 2 | Scissors = 3
    type Score =  Lost = 0 | Draw = 3 | Won = 6
    type Strategy =  Loose | Draw | Win

    type Match =
        { 
            P1: Action;
            P2: Strategy
        }

    type ScoredMatch = int   

    let fileToLines (inputFilePath : string) =
        File.ReadAllLines(inputFilePath)

    let parsePlayerOne(x: char) : Action =
        if x = 'A' then Action.Rock 
        elif x = 'B' then Action.Paper
        elif x = 'C' then Action.Scissors
        else raise (System.ArgumentException("Unexpected character."))

    let parsePlayerTwo(x: char) : Strategy =
        if x = 'X' then Strategy.Loose 
        elif x = 'Y' then Strategy.Draw
        elif x = 'Z' then Strategy.Win
        else raise (System.ArgumentException("Unexpected character."))
        
    let parseMatch(matchStr: string) : Match =
         { 
            P1 = parsePlayerOne (matchStr[0]);
            P2 = parsePlayerTwo (matchStr[2]) 
         }

    let scoreMatch(m : Match) : ScoredMatch = 
        match m with
        | {P1 = Action.Rock; P2 = Strategy.Loose} -> (int Action.Scissors) + (int Score.Lost)
        | {P1 = Action.Paper; P2 = Strategy.Loose} -> (int Action.Rock) + (int Score.Lost)
        | {P1 = Action.Scissors; P2 = Strategy.Loose} -> (int Action.Paper) + (int Score.Lost)

        | {P1 = Action.Rock; P2 = Strategy.Draw} -> (int Action.Rock) + (int Score.Draw)
        | {P1 = Action.Paper; P2 = Strategy.Draw} -> (int Action.Paper) + (int Score.Draw)
        | {P1 = Action.Scissors; P2 = Strategy.Draw} -> (int Action.Scissors) + (int Score.Draw)

        | {P1 = Action.Rock; P2 = Strategy.Win} -> (int Action.Paper) + (int Score.Won)
        | {P1 = Action.Paper; P2 = Strategy.Win} -> (int Action.Scissors) + (int Score.Won)
        | {P1 = Action.Scissors; P2 = Strategy.Win} -> (int Action.Rock) + (int Score.Won)

        | _ -> raise(System.ArgumentException("Unexpected match.")) 

        
    let parseToMatches (matches: string seq) : Match seq = 
        matches 
        |> Seq.map(fun x -> parseMatch x)

    let scoreMatches(matches: Match seq) : ScoredMatch seq = 
        matches
        |> Seq.map(scoreMatch)

