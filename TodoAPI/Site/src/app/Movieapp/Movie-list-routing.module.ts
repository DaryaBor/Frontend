import { RouterModule, Routes } from "@angular/router";
import { NgModule } from "@angular/core";
import { FilmListPageComponent } from "./movie-film-app-page/film-page.component";
const routes: Routes = [
    {
      path: 'film-list-page',
      component: FilmListPageComponent 
    },
    
  ];
  
  @NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
  })
  export class MovieListRoutingModule { }