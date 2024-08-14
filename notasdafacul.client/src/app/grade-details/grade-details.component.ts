import { Component, OnInit, HostListener } from '@angular/core';
import { GradeDetailsService } from '../shared/grade-details.service';
import { NgForm } from '@angular/forms'
import { GradeDetails } from '../shared/grade-details.model';


@Component({
  selector: 'app-grade-details',
  templateUrl: './grade-details.component.html',
  styleUrl: './grade-details.component.css'
})
export class GradeDetailsComponent implements OnInit {

  gridCols: number = 0;

  constructor(public service: GradeDetailsService) {
    this.setGridCols(window.innerWidth)
  }

  onSubmit(form : NgForm) {
    if (this.service.formData.id == 0) {
      this.insertRecord(form);
      window.location.reload();
    }
    else {
      this.updateRecord(form);
      window.location.reload();
    }
  }

  ngOnInit(): void {
    this.service.refreshList();
  }

  columnsToDisplay: string[] = ['course', 'grade', 'date', 'delete'];

  populateForm(selectedRecord: GradeDetails) {
    this.service.formData = Object.assign({}, selectedRecord);
  }

  insertRecord(form : NgForm) {
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

  updateRecord(form : NgForm) {
    this.service.putGradeDetails()
      .subscribe({
        next: res => {
          console.log(res)
        },
        error: err => {
          console.log(err)
        }
      })
  }

  deleteRecord(id : number) {
    this.service.deleteGradeDetails(id)
      .subscribe({
        next: res => {
          console.log(res)
        },
        error: err => {
          console.log(err)
        }
      });
    window.location.reload();
  }

  @HostListener('window:resize', ['$event'])
  onResize(event: { target: { innerWidth: number; }; }) {
    this.setGridCols(event.target.innerWidth);
  }

  setGridCols(width: number) {
    if (width < 768) {
      this.gridCols = 1;
    } else {
      this.gridCols = 2;
    }
  }
}
