import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
//import { FilmListPageComponent  } from "./Movieapp/movie-app-film-item/movie-film-app-page/film-page.component";
import { FilmListPageComponent } from "./Movieapp/movie-film-app-page/film-page.component";
const routes: Routes = [
  {
    path: '*',
    component: FilmListPageComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
