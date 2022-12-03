module AoC22.Day2

open System
open System.IO

type PlayType =
    | Rock
    | Paper
    | Scissors

type Outcome =
    | Win
    | Lose
    | Draw

let private fileSplitByLines: string [] =
    (File.ReadAllText "day2.txt").Split("\r\n")
    |> Array.filter (fun str -> not (Seq.isEmpty str))

let private parsePlay (str: String) : PlayType =
    match str with
    | "X"
    | "A" -> Rock
    | "Y"
    | "B" -> Paper
    | "Z"
    | "C" -> Scissors
    | invalid -> failwithf $"Can't parse play: %s{invalid}"

let private parseOutcome (str: String) : Outcome =
    match str with
    | "X" -> Lose
    | "Y" -> Draw
    | "Z" -> Win
    | invalid -> failwithf $"Can't parse outcome %s{invalid}"

let private getWinningHand (opponentHand: PlayType) : PlayType =
    match opponentHand with
    | Rock -> Paper
    | Paper -> Scissors
    | Scissors -> Rock

let private getLosingHand (opponentHand: PlayType) : PlayType =
    match opponentHand with
    | Rock -> Scissors
    | Paper -> Rock
    | Scissors -> Paper

let private playToPoints (play: PlayType) : int =
    match play with
    | Rock -> 1
    | Paper -> 2
    | Scissors -> 3

let private outcomeToPoints (outcome: Outcome) : int =
    match outcome with
    | Win -> 6
    | Draw -> 3
    | Lose -> 0

let private calcPoints ((opponent, me): (PlayType * PlayType)) : int =
    let outcome =
        match (opponent, me) with
        | o, m when o = m -> Draw
        | o, m when getWinningHand o = m -> Win
        | _ -> Lose

    (outcomeToPoints outcome) + (playToPoints me)

let private strPlaysToPlays (str: string) : PlayType * PlayType =
    let arr = str.Split(" ")
    let opponent = parsePlay arr[0]
    let myPlay = parsePlay arr[1]
    (opponent, myPlay)

let private strPlayAndOutcomeToPlays (str: string) : PlayType * PlayType =
    let arr = str.Split(" ")
    let opponent = parsePlay arr[0]
    let outcome = parseOutcome arr[1]

    let myPlay =
        match (opponent, outcome) with
        | _, Draw -> opponent
        | o, Win -> getWinningHand o
        | o, Lose -> getLosingHand o

    (opponent, myPlay)

let firstStar () : int =
    fileSplitByLines
    |> Seq.map (fun str -> str |> strPlaysToPlays |> calcPoints)
    |> Seq.sum

let secondStar () : int =
    fileSplitByLines
    |> Seq.map (fun str -> str |> strPlayAndOutcomeToPlays |> calcPoints)
    |> Seq.sum
