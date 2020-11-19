module App

open Fable.SignalR
open Fable.SignalR.Feliz
open Elmish
open Feliz
open Feliz.Router
open Feliz.UseElmish
open Somnifs.Library

[<RequireQualifiedAccess>]
type Page =
    | Home
    | Viewer
    | Broadcaster
    | NotFound

type State = { Page: Page }
type Msg = PageChanged of Page


let parseUrl =
    function
    | [] -> Page.Home
    | [ "view" ] -> Page.Viewer
    | [ "broadcast" ] -> Page.Broadcaster
    // matches everything else
    | _ -> Page.NotFound

let init () =
    { Page = Router.currentUrl () |> parseUrl }, Cmd.none

let update msg state =
    match msg with
    | PageChanged page -> { state with Page = page }, Cmd.none


let private app' () =
    let state, dispatch = React.useElmish (init, update, [||])

    let hub =
        React.useSignalR<Action, Response> (fun hub ->
            hub.withUrl(sprintf "%s%s" Endpoints.BaseUrl Endpoints.Root)
               .withAutomaticReconnect().configureLogging(LogLevel.Debug).onMessage
            <| function
            | Response.NewCount i -> ())

    React.router [
        router.onUrlChanged (parseUrl >> PageChanged >> dispatch)

        router.children [
            match state.Page with
            | Page.Home -> Home.Page()
            | Page.Viewer -> Viewer.Page {| hub = hub |}
            | Page.Broadcaster -> Broadcaster.Page {| hub = hub |}
            | Page.NotFound -> NotFound.Page()

        ]
    ]


let App =
    React.functionComponent ("Somnicall", app')
