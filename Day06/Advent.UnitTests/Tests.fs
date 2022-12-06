namespace Advent.UnitTests

open Advent
open Microsoft.VisualStudio.TestTools.UnitTesting

module TestData = 
    [<TestClass>]
    type Test () =
        let input = [
            ("mjqjpqmgbljsphdztnvjfqwrcgsmlb", 7 ); 
            ("bvwbjplbgvbhsrlpgdmjqwftvncz", 5);
            ("nppdvjthqldpwncqszvftbrmjlhg", 6);
            ("nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg", 10);
            ("zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw", 11)
        ]

        [<TestMethod>]
        member this.Task1 () =
            input |> Seq.iter(fun x -> Assert.AreEqual(Part1.run (fst x) 4, (snd x)))
            Assert.AreEqual(0, 0)

        [<TestMethod>]
        member this.Task2 () =
            Assert.AreEqual(0, 0)
