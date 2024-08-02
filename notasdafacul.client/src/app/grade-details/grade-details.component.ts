import { Component, OnInit } from '@angular/core';
import { GradeDetailsService } from '../shared/grade-details.service';
import { NgForm } from '@angular/forms'


@Component({
  selector: 'app-grade-details',
  templateUrl: './grade-details.component.html',
  styleUrl: './grade-details.component.css'
})
export class GradeDetailsComponent implements OnInit {

  constructor(public service: GradeDetailsService) {

  }

  onSubmit(form: NgForm) {
    this.service.postGradeDetails()
      .subscribe({
        next: res => {
          console.log(res)
        },
        error: err => {
          console.log(err)
        }
      })
  }

  ngOnInit(): void {
    this.service.refreshList();
  }

  columnsToDisplay: string[] = ['course', 'grade', 'date'];

}
