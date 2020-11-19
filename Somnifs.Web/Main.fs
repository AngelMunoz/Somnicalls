module Main

open Fable.Core.JsInterop
open Browser.Dom
open Feliz

importAll "./styles/main.scss"


ReactDOM.render(App.App(), document.getElementById "feliz-app")