module Broadcaster

open Fable.SignalR
open Elmish
open Feliz
open Feliz.Router
open Feliz.UseElmish

open Somnifs.Library

let private broadcaster' (props: {| hub: Hub<Action, Response> |}) =
    Html.article [ prop.text "Broadcastor"]


let Page = React.functionComponent("Broadcaster", broadcaster')
