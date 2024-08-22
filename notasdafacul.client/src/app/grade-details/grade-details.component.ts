import { Component, OnInit, HostListener, ChangeDetectionStrategy, inject } from '@angular/core';
import { GradeDetailsService } from '../shared/grade-details.service';
import { NgForm } from '@angular/forms'
import { GradeDetails } from '../shared/grade-details.model';
import { MatDialog, MatDialogModule } from '@angular/material/dialog';
import { MatButtonModule } from '@angular/material/button';


@Component({
  selector: 'app-grade-details',
  templateUrl: './grade-details.component.html',
  styleUrl: './grade-details.component.css'
})
export class GradeDetailsComponent implements OnInit {

  gridCols: number = 0;

  ngOnInit(): void {
    this.service.refreshList();
  }

  columnsToDisplay: string[] = ['course', 'grade', 'date', 'delete'];

  populateForm(selectedRecord: GradeDetails) {
    this.service.formData = Object.assign({}, selectedRecord);
  }

  constructor(public service: GradeDetailsService, private dialog: MatDialog) {
    this.setGridCols(window.innerWidth)
  }

  onSubmit(form: NgForm) {
    if (this.service.formData.id == 0) {
      this.insertRecord(form);
      window.location.reload();
    }
    else {
      this.updateRecord(form);
      window.location.reload();
    }
  }

  insertRecord(form: NgForm) {
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

  updateRecord(form: NgForm) {
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

  deleteRecord(id: number) {
    const dialogRef = this.dialog.open(DeleteDialogComponent);

    dialogRef.afterClosed().subscribe({
      next: res => {
        if (res) { 
          this.service.deleteGradeDetails(id).subscribe({
            next: () => {
              console.log(res);
              this.service.refreshList();
            },
            error: err => {
              console.log(err);
            }
          });
        }
      },
      error: err => {
        console.log(err);
      }
    });
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

@Component({
  selector: 'delete-dialog',
  templateUrl: 'delete-dialog/delete-dialog.component.html',
  standalone: true,
  imports: [MatDialogModule, MatButtonModule],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class DeleteDialogComponent {

}
