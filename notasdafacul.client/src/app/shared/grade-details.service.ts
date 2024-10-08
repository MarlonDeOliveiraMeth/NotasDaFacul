import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'
import { environment } from '../../environments/environment';
import { GradeDetails } from './grade-details.model';

@Injectable({
  providedIn: 'root'
})
export class GradeDetailsService {

  url: string = environment.apiBaseUrl + '/Grades'
  list: GradeDetails[] = [];
  formData: GradeDetails = new GradeDetails();
  constructor(private http: HttpClient) { }

  refreshList() {
    this.http.get(this.url).subscribe({
      next: res => {
        this.list = res as GradeDetails[];
      },
      error: err => {
        console.log(err)
      }
    })
  }

  postGradeDetails() {
    return this.http.post(this.url, this.formData);
  }

  putGradeDetails() {
    return this.http.put(this.url + '/' + this.formData.id, this.formData);
  }

  deleteGradeDetails(id : number) {
    return this.http.delete(this.url + '/' + id);
  }
}
