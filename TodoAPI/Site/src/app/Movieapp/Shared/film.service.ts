import { Injectable } from "@angular/core";
import { IFilm } from './film.interface';
import { ISeance } from "../Shared/seance.interface";
import { ITickets } from "../Shared/tickets.interface";
import { Observable } from "rxjs";
import { HttpClient } from "@angular/common/http";

@Injectable()
export class FilmService {
  private readonly apiUrl: string = 'http://localhost:4200/api';

  constructor(private httpClient: HttpClient) {
  }

  public getFilm(): Observable<IFilm[]> {
    return this.httpClient.get<IFilm[]>(`${this.apiUrl}/film`);
  }

  public getSeance(): Observable<ISeance[]> {
    return this.httpClient.get<ISeance[]>(`${this.apiUrl}/seance`);
  }

  public getTickets(): Observable<ITickets[]> {
    return this.httpClient.get<ITickets[]>(`${this.apiUrl}/ticket`);
  }

  public updateFilm(film: IFilm): void {
    this.httpClient.get(`${this.apiUrl}/film/update/name/${film.denomination}/${film.dateStart}/${film.company}`).subscribe();
  }
   
  public addFilm(film: IFilm): void {
    this.httpClient.get(`${ this.apiUrl } / film / add / ${ film.denomination } / ${ film.dateStart } / ${ film.company }`).subscribe();
  }

  public deleteFilmById(id: number): void {
    this.httpClient.get(`${this.apiUrl}/film/delete/${id}`).subscribe();
  }

 
}
