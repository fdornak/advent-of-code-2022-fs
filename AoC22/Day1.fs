module AoC22.Day1

open System.IO

let private readFileIntoGroups: string [] =
    let input = File.ReadAllText "day1.txt"
    input.Split("\n\r")

let private countForOne (str: string) : int =
    str.Split("\n")
    |> Seq.filter (fun x -> x |> Seq.isEmpty |> not)
    |> Seq.map int
    |> Seq.sum

let firstStar () : int =
    readFileIntoGroups
    |> Seq.map countForOne
    |> Seq.max

let secondStar () : int =
    readFileIntoGroups
    |> Seq.map countForOne
    |> Seq.sortDescending
    |> Seq.take 3
    |> Seq.sum
