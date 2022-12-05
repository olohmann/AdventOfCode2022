namespace Advent
open System.Text.RegularExpressions

module Part1 =
    let (|Regex|_|) pattern input =
        let m = Regex.Match(input, pattern)
        if m.Success then Some(List.tail [ for g in m.Groups -> g.Value ])
        else None

    let moveBoxes (count: int, fromPos :int, toPos :int, stacks: list<string> array) =
        // Mutable array - buuuuuuuuuuuuh!
        for i in 1..count do
            let (top, rest) = stacks[fromPos - 1] |> fun x -> (x |> List.take(1), x|> List.skip(1))
            stacks[fromPos - 1] <- rest
            stacks[toPos - 1] <-  top @ stacks[toPos - 1]

    let run(lines : string seq, stacks: list<string> array) =
        lines 
        |> Seq.map(fun x -> 
            match x with 
            | Regex "move (\d+) from (\d+) to (\d+)" [ count; fromPos; toPos ] -> 
                {| count = count |> int; fromPos = fromPos |> int; toPos = toPos |> int |}
            | _ -> raise (System.ArgumentException("unexpected argument")))
        |> Seq.iter (fun x -> 
            moveBoxes (x.count, x.fromPos, x.toPos, stacks)
        )

