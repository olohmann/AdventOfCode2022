namespace Advent

module Part1 =

    type FileTree =
        | File of string * int
        | Directory of string * FileTree list

    let rec printFiles (tree: FileTree, indent: int) =
        match tree with
        | File(name, size) ->
            printfn "%s (file, size=%i) %i" name size indent
        | Directory(name, children) ->
            printfn "%*s (dir)" indent name 
            children |> List.iter(fun x -> printFiles  (x, indent + 2))

    
    let run(lines : string seq) =
        let tree =
            Directory("root", [
                Directory("dir1", [
                    File("file1.txt", 100);
                    File("file2.txt", 200)
                ]);
                Directory("dir2", [
                    File("file3.txt", 10);
                    File("file4.txt", 40)
                ])
            ])
        printFiles (tree, 0)
        0
