import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Task } from '../TaskModel';

@Injectable({
  providedIn: 'root'
})
export class TaskService {

  private apiUrl = "http://localhost:8080/TasksContoller";

  constructor(private http: HttpClient) { }

  getTasks(): Observable<Task[]> {
    return this.http.get<Task[]>(this.apiUrl)
  }

  deleteTask(task: Task): Observable<Task> {
    return this.http.delete<Task>(`${this.apiUrl}?taskId=${task.id}`)
  }

  updateTask(task: Task): Observable<Task> {
    return this.http.put<Task>(`${this.apiUrl}?taskId=${task.id}`, task)
  }

  addTask(task: Task): Observable<Task> {
    return this.http.post<Task>(`${this.apiUrl}`, task);
  }
}
