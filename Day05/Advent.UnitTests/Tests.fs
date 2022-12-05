namespace Advent.UnitTests

open Advent
open Microsoft.VisualStudio.TestTools.UnitTesting

module TestData = 
    [<TestClass>]
    type Test () =
        let input = """
    [D]    
[N] [C]    
[Z] [M] [P]
 1   2   3 

move 1 from 2 to 1
move 3 from 1 to 3
move 2 from 2 to 1
move 1 from 1 to 2"""   

        [<TestMethod>]
        member this.Task1 () =
            let x = [|["N"; "Z"]; ["D"; "C"; "M"]; ["P"]|]
            Part1.run(input.Split(System.Environment.NewLine) |> Seq.skip(6), x)
            Assert.AreEqual(1, x[0].Length)
            Assert.AreEqual(1, x[1].Length)
            Assert.AreEqual(4, x[2].Length)

        [<TestMethod>]
        member this.Task2 () =
            let x = [|["N"; "Z"]; ["D"; "C"; "M"]; ["P"]|]
            Part2.run(input.Split(System.Environment.NewLine) |> Seq.skip(6), x)
            Assert.AreEqual(1, x[0].Length)
            Assert.AreEqual(1, x[1].Length)
            Assert.AreEqual(4, x[2].Length)



