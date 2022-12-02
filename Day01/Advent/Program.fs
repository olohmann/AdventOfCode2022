open Advent

let highest = Elves.fileToLines(@"./input.txt") |> Elves.parseElvenCaloriesList |> Elves.highestSum
let topThree = Elves.fileToLines(@"./input.txt")|> Elves.parseElvenCaloriesList  |> Elves.topThreeSum

printfn "The Answer #1 is: %i" highest
printfn "The Answer #2 is: %i" topThree
