import { Component, Input, OnInit, Output } from '@angular/core';
import {MovieDetail} from 'src/app/shared/models/movie-detail';
import { ActivatedRoute } from '@angular/router';
import { DatePipe } from '@angular/common';
import { NumberValueAccessor } from '@angular/forms';
import { MovieService } from 'src/app/core/service/movie.service';
import { MovieCard } from 'src/app/shared/models/moviecard';

@Component({
  selector: 'app-movie-details',
  templateUrl: './movie-details.component.html',
  styleUrls: ['./movie-details.component.css']
})

export class MovieDetailsComponent implements OnInit {
  movie!:MovieDetail;
  constructor(private movieService:MovieService) { }
  ngOnInit(): void {
    this.movieService.getMovieDetails().subscribe(m=>{this.movie=m;});
  }
}
