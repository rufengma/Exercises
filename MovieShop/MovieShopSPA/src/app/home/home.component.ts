import { Component, OnInit } from '@angular/core';
import { MovieService } from '../core/service/movie.service';
import { MovieCard } from '../shared/models/moviecard';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  // : is equifalent to = , fu zhi.
  movies!: MovieCard[];
  constructor(private movieService:MovieService) { }

  ngOnInit(): void {// a part of component Life Cycle Hooks,  a life cycle includes many events
    // ngOnInit: fetch the data
    this.movieService.getTopRevenueMovies()
    .subscribe(m=>{this.movies=m;});// we can do not include this one.  console.table(this.movies)
  }
}
