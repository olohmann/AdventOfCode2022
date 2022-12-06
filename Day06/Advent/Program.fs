open Advent

let p1 = Part1.run
let p2 = Part2.run

printfn "The Answer #1 is: %A" (Helper.readFile |> Seq.head |> p1)
printfn "The Answer #2 is: %A" (Helper.readFile |> Seq.head |> p2)
