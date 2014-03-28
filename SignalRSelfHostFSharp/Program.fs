namespace Program

open Owin
open Dynamic
open Microsoft.AspNet.SignalR
open Microsoft.AspNet.SignalR.Hubs
open Microsoft.Owin.Hosting
open Microsoft.Owin.Cors
open System
open System.Diagnostics

type MyHub =
    inherit Hub
    member x.Send (name : string) (message : string) =
        base.Clients.All?addMessage name message

type MyWebStartUp() =
    member x.Configuration (app :IAppBuilder) =
        app.UseCors CorsOptions.AllowAll |> ignore
        app.MapSignalR() |> ignore
        ()

module Starter =

    [<EntryPoint>]
    let main argv = 
        let hostUrl = "http://localhost:8085"
        let disposable = WebApp.Start<MyWebStartUp>(hostUrl)
        Console.WriteLine("Server running on "+ hostUrl)
        Console.ReadLine() |> ignore
        disposable.Dispose() 
        0 // return an integer exit code