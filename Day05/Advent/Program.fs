open Advent

let p1 = Part1.run
let p2 = Part2.run

let x = [|
    [ "F";"G";"V";"R";"J";"L";"D" ]; 
    [ "S";"J";"H";"V";"B";"M";"P";"T" ]; 
    [ "C";"P";"G";"D";"F";"M";"H";"V" ];
    [ "Q";"G";"N";"P";"D";"M" ]; 
    [ "F";"N";"H";"L";"J" ];
    [ "Z";"T";"G";"D";"Q";"V";"F";"N" ];
    [ "L";"B";"D";"F" ];
    [ "N";"D";"V";"S";"B";"J";"M" ];
    [ "D";"L";"G" ];
|]

let y = [|
    [ "F";"G";"V";"R";"J";"L";"D" ]; 
    [ "S";"J";"H";"V";"B";"M";"P";"T" ]; 
    [ "C";"P";"G";"D";"F";"M";"H";"V" ];
    [ "Q";"G";"N";"P";"D";"M" ]; 
    [ "F";"N";"H";"L";"J" ];
    [ "Z";"T";"G";"D";"Q";"V";"F";"N" ];
    [ "L";"B";"D";"F" ];
    [ "N";"D";"V";"S";"B";"J";"M" ];
    [ "D";"L";"G" ];
|]


Part1.run (Helper.readFile() |> Seq.skip(10), x)
Part2.run (Helper.readFile() |> Seq.skip(10), y)

printfn "The Answer #1 is: %A" (x |> Seq.map(fun x -> fst (Part1.pop x)) |> Seq.toArray |> String.concat "")
printfn "The Answer #2 is: %A" (y |> Seq.map(fun y -> fst (Part1.pop y)) |> Seq.toArray |> String.concat "")
