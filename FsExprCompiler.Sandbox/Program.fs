﻿module Program

open System
open Expr
open Microsoft.FSharp.Text.Lexing

let input = "2.0 + 5 * (FOO - BAR) + 1000"

let lexbuf = input |> LexBuffer<_>.FromString
let parse = ExprParser.start ExprLexer.tokenize
let expr =  lexbuf |> parse

printfn "%A" expr

Console.ReadKey(true) |> ignore