import { Component, OnInit } from '@angular/core';
import { GradeDetailsService } from '../shared/grade-details.service';

@Component({
  selector: 'app-grade-details',
  templateUrl: './grade-details.component.html',
  styleUrl: './grade-details.component.css'
})
export class GradeDetailsComponent implements OnInit {

  constructor(public service: GradeDetailsService) {

  }
  ngOnInit(): void {
    this.service.refreshList();
    }

}
