import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-result',
  templateUrl: './result.component.html',
  styleUrls: ['./result.component.scss']
})
export class ResultComponent implements OnInit {
  resultText: string;

  constructor() {
    this.resultText = 'default';
  }

  ngOnInit(): void {
  }

}
