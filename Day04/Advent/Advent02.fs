namespace Advent

module Part2 =
    let parseSequence(sequence: string) = 
        let i = sequence.Split("-")
        seq { i[0] |> int .. 1 .. i[1] |> int }

    let hasIntersection(line : string) =
        let i = line.Split(",") 
        seq { parseSequence(i[0]) |> Set.ofSeq; parseSequence(i[1]) |> Set.ofSeq }
        |> Set.intersectMany
        |> Set.count > 0

    let runInner(lines : string seq) =
        lines
        |> Seq.map hasIntersection
        |> Seq.filter id // only take 'true's
        |> Seq.length

    let run =
        Helper.readFile() 
        |> runInner
