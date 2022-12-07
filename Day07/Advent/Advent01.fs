namespace Advent
open FSharpx

module Part1 =

    type FileSystem = Map<string, int option>

    let cmd_cd(dirName: string, currentDir: string, fileSystem: FileSystem) =
        match dirName with
        | ".." ->
            let t = currentDir.Remove(currentDir.TrimEnd('/').LastIndexOf('/')+1)
            (t, fileSystem)
        | _ -> 
            let dir = currentDir + if dirName.EndsWith("/") then dirName else dirName + "/"
            if (fileSystem.ContainsKey(dir)) then (dir, fileSystem) else (dir, fileSystem.Add(dir, None))

    let rec addFile(file: (string * int), currentDir: string, fileSystem: FileSystem) =
        (currentDir, fileSystem.Add(currentDir + fst file, Some(snd file)))

    let printFileSystem(fileSystem: FileSystem) =
        fileSystem |> Seq.iter(fun x -> 
                let indent = x.Key |> Seq.where(fun x -> x = '/') |> Seq.skip(1) |> Seq.map(fun _ -> "  ") |> String.concat("") 
                match x.Value with
                | Some(i) -> printfn "%s- %s (file, size=%i)" indent x.Key i
                | None -> printfn "%s- %s (dir)" indent x.Key
            )

    let rec parseInput(lines : string list, currentDir: string, fileSystem: FileSystem) =
        match lines with
        | [] -> (currentDir, fileSystem)
        | line :: rest -> 
            let (currentDir, fileSystem) = 
                if line.StartsWith("$ cd ") then cmd_cd(line.Remove(0, "$ cd ".Length), currentDir, fileSystem) 
                elif line.StartsWith("$ ls") then (currentDir, fileSystem)
                elif line.StartsWith("dir ") then (currentDir, fileSystem)
                else addFile((line.Split(' ')[1], line.Split(' ')[0] |> int), currentDir, fileSystem)
            parseInput(rest, currentDir, fileSystem)

    let run(lines : string seq) =
        let (_, fileSystem) = parseInput(lines |> Seq.toList, "", Map.empty)
        let directories = fileSystem |> Map.filter(fun k v -> v = None) |> Map.keys 

        let directorySizes = directories 
                                |> Seq.map(fun d -> fileSystem |> Map.filter(fun k v -> k.StartsWith(d)) |> Seq.sumBy(fun x -> if x.Value = None then 0 else x.Value.Value))
                                |> Seq.where(fun d -> d <= 100000)
                                |> Seq.sum

        let totalUsed = fileSystem 
                                |> Seq.sumBy(fun x -> if x.Value = None then 0 else x.Value.Value)

        let totalSize = 70000000
        let totalRequired = 30000000
        let stillFree = totalSize - totalUsed 
        let additionalReq = stillFree - totalRequired
        // 7gb - 4GB = 3DB REST

        let totalUsed = directories 
                                |> Seq.map(fun d -> (d, fileSystem |> Map.filter(fun k v -> k.StartsWith(d)) |> Seq.sumBy(fun x -> if x.Value = None then 0 else x.Value.Value)))
                                |> Seq.map(fun x -> (fst x, (snd x, snd x + additionalReq)))
                                |> Seq.filter(fun x ->  snd (snd x) > 0)
                                |> Seq.sortBy(fun x -> snd (snd x))
 
        
        (*
        |> Seq.map(
            fun k -> fileSystem 
            |> Map.filter(fun kk vv -> kk.StartsWith(k)) 
            |> Map.values 
            |> Seq.sum))
            *)

        //printfn "Current Directory: %s" currentDir
        //printfn "%A" (directorySizes)
        printfn "%A" (totalUsed |> Seq.toArray)
        0

 
(*
    type FileTree =
        | File of string * int
        | Directory of string * FileTree list

    let generatePadding (indent: int) =
        match indent with 
        | 0 -> ""
        | _ -> seq { 1 .. indent } |> Seq.map(fun _ -> " ") |> String.concat("") 

    let rec printFiles (tree: FileTree, indent: int) =
        match tree with
        | File(name, size) ->
            printfn "%s%s (file, size=%i)" (generatePadding indent)  name size 
        | Directory(name, children) ->
            printfn "%s%s (dir)" (generatePadding indent) name 
            children |> List.iter(fun x -> printFiles  (x, indent + 2))

    let cmd_cd () =
        match tree with
        | File(name, size) ->
            printfn "%s%s (file, size=%i)" (generatePadding indent)  name size 
        | Directory(name, children) ->
*)

