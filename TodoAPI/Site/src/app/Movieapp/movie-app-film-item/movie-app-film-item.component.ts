import { Component, EventEmitter, Input, Output } from "@angular/core";
import { IFilm } from "../Shared/film.interface";

@Component({
  selector: 'tl-film-list-item',
  templateUrl: './movie-app-film-item.component.html'
})

export class FilmListItemComponent {
  displayedColumns: string[] = ['id','denomination','dateStart','company'];
  @Input() public dataSource: IFilm[];
  @Output() public add: EventEmitter<IFilm> = new EventEmitter<IFilm>();
  @Output() public delete: EventEmitter<IFilm> = new EventEmitter<IFilm>();

  public deleteClicked(element: IFilm): void {
    this.delete.emit(element);
  }

  public addClicked(element: IFilm): void {
    this.add.emit(element);
  }
}
