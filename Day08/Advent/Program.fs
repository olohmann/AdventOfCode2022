open Advent

let input = Helper.readInput

let create2D_map(lines: string list) =
    Array2D.zeroCreate<int> lines.Length lines.Head.Length

let fillMap(lines: string list) (array: int[,]) : unit =
    lines |> Seq.iteri(fun i x -> (x |> Seq.iteri(fun j y -> array[i,j]  <- y.ToString() |> int)))

// Helper function as Array2D has no .toSeq
let getAllElements (a:'a[,]) : seq<'a> =
    seq { for i in 0 .. a.GetLength(0) - 1 do for j in 0 .. a.GetLength(1) - 1 do yield a.[i,j] }

let fillBoundary(s: int seq): int seq =
    if Seq.isEmpty(s) then [-1] else s

let line1(x:int) (y:int) (a : int[,]): int seq = 
    seq { for i in a.GetLowerBound(0) .. x - 1 do yield a[i , y] } |> Seq.rev

let line2(x:int) (y:int) (a : int[,]): int seq = 
    seq { for i in x + 1 .. a.GetUpperBound(0) do yield a[i, y] } 

let line3(x:int) (y:int) (a : int[,]): int seq = 
    seq { for i in a.GetLowerBound(1) .. y - 1 do yield a[x, i] } |> Seq.rev

let line4(x:int) (y:int) (a : int[,]): int seq = 
    seq { for i in y + 1 .. a.GetUpperBound(1) do yield a[x, i] } 

let isTreeVisible(x:int) (y:int) (a : int[,]): bool =
    // Tree is visible if there is one line where it is the max height
    let lines = [line1 x y a; line2 x y a; line3 x y a; line4 x y a]
    lines |> Seq.map(fillBoundary) |> Seq.exists(fun i -> i |> Seq.max < a[x,y])

let rec scenicScoreByLine(v:int) (line: int list) : int =
    match line with
    | [] -> 0
    | hd :: tl -> if hd < v then 1 + scenicScoreByLine v tl elif hd = v then 1 else 0

let scenicScore(x:int) (y:int) (a : int[,]): int =
    // Scenic is a bit different to visibility test with special case of "boundary" trees.
    let lines = [line1 x y a; line2 x y a; line3 x y a; line4 x y a]
    lines |> Seq.map(fun s -> if Seq.isEmpty(s) then 0 else scenicScoreByLine a[x,y] (s |> Seq.toList)) |> Seq.reduce (*)

let countVisibleTrees(a: int[,]): int =
    a |> Array2D.mapi(fun x y _ -> if isTreeVisible x y a then 1 else 0 ) |> getAllElements |> Seq.sum

let highestScenicScore(a: int[,]): int = 
    a |> Array2D.mapi(fun x y _ -> scenicScore x y a) |> getAllElements |> Seq.max
            
let test =
    let testInput = Helper.readTestInput
    let a = create2D_map testInput
    fillMap (testInput) a
    printfn "(Test) Total Visible Trees: %i" (countVisibleTrees a)

let task1 =
    let input = Helper.readInput
    let a = create2D_map input
    fillMap (input) a
    printfn "#1 Total Visible Trees: %i" (countVisibleTrees a)

let task2 =
    let input = Helper.readInput
    let a = create2D_map input
    fillMap (input) a
    printfn "#2 Highest Scenic Score: %i" (highestScenicScore a)
     
task1
task2

(*
#1 Total Visible Trees: 1693
#2 Highest Scenic Score: 422059
*)
