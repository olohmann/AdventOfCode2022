open Advent

let p1 = Part1.run
let input = Helper.readFile |> Seq.head

printfn "The Answer #1 is: %A" (p1 input 4)
printfn "The Answer #2 is: %A" (p1 input 14)
