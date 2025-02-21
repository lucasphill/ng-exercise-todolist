import { Component, Input, Output, EventEmitter } from '@angular/core';
import { Task } from '../../TaskModel';
import { faTimes } from '@fortawesome/free-solid-svg-icons'
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome'
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-task-item',
  imports: [FontAwesomeModule, CommonModule],
  templateUrl: './task-item.component.html',
  styleUrl: './task-item.component.css'
})
export class TaskItemComponent {
  @Input() task!: Task;
  @Output() onDeleteTask = new EventEmitter<Task>();
  @Output() onToggleFinish = new EventEmitter<Task>();

  faTimes = faTimes;

  onDelete(task: Task) {
    this.onDeleteTask.emit(task);
  }

  onToggle(task: Task) {
    this.onToggleFinish.emit(task)
  }
}
