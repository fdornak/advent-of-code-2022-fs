module AoC22.Day5Test

open Xunit
open FsUnit.Xunit

[<Fact>]
let ``Day 5`` () =
    Day5.firstStar () |> should equal "ZRLJGSCTR"
    Day5.secondStar () |> should equal "PRTTGRFPB"
