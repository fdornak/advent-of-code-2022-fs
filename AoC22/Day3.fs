module AoC22.Day3

open System.IO

type Rucksack = { Left: Set<char>; Right: Set<char> }

let fileSplitByLines: string [] =
    (File.ReadAllText "day3.txt").Split("\r\n")
    |> Array.filter (fun str -> not (Seq.isEmpty str))

let strIntoRucksack (str: string) : Rucksack =
    let length = str.Length
    let leftLength = length / 2
    let left = str |> Seq.take leftLength |> Set

    let right =
        str |> Seq.skip leftLength |> Set

    { Left = left; Right = right }

let findIntersectInCompartments (rucksack: Rucksack) : char =
    Set.intersect rucksack.Left rucksack.Right
    |> Set.minElement

let findIntersectInGroup (group: string []) : char =
    group
    |> Seq.map (fun x -> Set.ofSeq x)
    |> Set.intersectMany
    |> Set.minElement

let charValue (c: char) : int =
    match c with
    | c when c >= 'a' && c <= 'z' -> ((int) c) - 97 + 1
    | c when c >= 'A' && c <= 'Z' -> ((int) c) - 65 + 27
    | _ -> failwithf $"Can't assign value to ${c}"

let firstStar () : int =
    let rucksacks = fileSplitByLines

    rucksacks
    |> Seq.map (fun str ->
        str
        |> strIntoRucksack
        |> findIntersectInCompartments
        |> charValue)
    |> Seq.sum

let secondStar () : int =
    let file = fileSplitByLines
    let groups = file |> Array.chunkBySize 3

    groups
    |> Seq.map (fun grp -> grp |> findIntersectInGroup |> charValue)
    |> Seq.sum
