module AoC22.Day6Test

open Xunit
open FsUnit.Xunit

[<Fact>]
let ``Day 6`` () =
    Day6.firstStar () |> should equal 1142
    Day6.secondStar () |> should equal 2803
