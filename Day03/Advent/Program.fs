open Advent

let scoresTask1 = ElvishRucksacksPart1.fileToLines(@"./input.txt") |>  ElvishRucksacksPart1.calculateAll
let scoresTask2 = ElvishRucksacksPart2.fileToLines(@"./input.txt") |>  ElvishRucksacksPart2.calculateAll

printfn "The Answer #1 is: %i" (scoresTask1)
printfn "The Answer #2 is: %i" (scoresTask2)
