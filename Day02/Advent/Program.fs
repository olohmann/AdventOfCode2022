open Advent

let scoresTask1 = ElvishRockPaperScissorsStrategy.fileToLines(@"./input.txt") |> ElvishRockPaperScissorsStrategy.parseToMatches |> ElvishRockPaperScissorsStrategy.scoreMatches 
let scoresTask2 = ElvishRockPaperScissorsStrategyDecrypted.fileToLines(@"./input.txt") |> ElvishRockPaperScissorsStrategyDecrypted.parseToMatches |> ElvishRockPaperScissorsStrategyDecrypted.scoreMatches 

printfn "The Answer #1 is: %i" (scoresTask1 |> Seq.sum)
printfn "The Answer #2 is: %i" (scoresTask2 |> Seq.sum)
