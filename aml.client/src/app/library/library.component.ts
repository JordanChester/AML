import {Component, Input, input, OnInit} from '@angular/core';
import {Media} from "../Models/Media";

@Component({
  selector: 'app-library',
  templateUrl: './library.component.html',
  styleUrl: './library.component.css'
})
export class LibraryComponent implements OnInit{

  @Input() search: string = '';
  mediaList: Media[] = [];
  ngOnInit(): void {
    this.mediaList = [{
      name: 'name',
      price: 0,
      isAvailable: true,
      mediaType: 'Video',
      description: 'test description',
    },
      {
        name: 'name2',
        price: 0,
        isAvailable: true,
        mediaType: 'Video',
        description: 'test description2',
      }];
  }
}
