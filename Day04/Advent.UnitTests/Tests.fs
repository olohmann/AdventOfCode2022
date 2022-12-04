namespace Advent.UnitTests

open System
open Advent
open Microsoft.VisualStudio.TestTools.UnitTesting

module TestData = 
    [<TestClass>]
    type Test () =
        let input = """2-4,6-8
2-3,4-5
5-7,7-9
2-8,3-7
6-6,4-6
2-6,4-8"""   

        [<TestMethod>]
        member this.Task1 () =
            let actual = Part1.runInner(input.Split(System.Environment.NewLine))
            Assert.AreEqual(2, actual)

        [<TestMethod>]
        member this.Task2 () =
            let actual = Part2.runInner(input.Split(System.Environment.NewLine))
            Assert.AreEqual(4, actual)



