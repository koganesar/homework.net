﻿module WebApplicationFs.Views

type Message = { Text: string }
open Giraffe.ViewEngine


let layout (content: XmlNode list) =
    html [] [
        head [] [
            title [] [ encodedText "qwe" ]
            link [ _rel "stylesheet"
                   _type "text/css"
                   _href "main.css" ]
        ]
        body [] content
    ]

let partial () = h1 [] [ encodedText "qwe" ]

let index (model: Message) =
    [ partial ()
      p [] [ encodedText model.Text ] ]
    |> layout
