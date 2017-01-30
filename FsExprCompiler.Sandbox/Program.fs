module Program

open System
open Expr
open Microsoft.FSharp.Text.Lexing

let input = "2.0 + 5 * (FOO - BAR) + 1000 * (-4+8-3+2)"

let lexbuf = input |> LexBuffer<_>.FromString
let parse = ExprParser.start ExprLexer.tokenize
let expr =  lexbuf |> parse

printfn "%A" expr

Console.ReadKey(true) |> ignore

let calculator = Compiler.compile input
let resolver var =
    match var with
    | "FOO" -> 100.0
    | "BAR" -> 50.0
    | _ -> failwith "Unrecognized variable"
let result = calculator resolver

printfn "%f" result

Console.ReadKey(true) |> ignore
