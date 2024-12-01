import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MediaComponent } from './media.component';
import {FormsModule} from "@angular/forms";
import {provideHttpClient} from "@angular/common/http";
import {Media} from "../_models/Media";
import {Router} from "@angular/router";

describe('MediaComponent', () => {
  let component: MediaComponent;
  let fixture: ComponentFixture<MediaComponent>;
  let router: jasmine.SpyObj<Router>;

  beforeEach(async () => {
    const routerSpy = jasmine.createSpyObj('Router', ['navigate']);

    await TestBed.configureTestingModule({
      declarations: [MediaComponent],
      imports: [FormsModule],
      providers: [provideHttpClient(),
        { provide: Router, useValue: routerSpy }]
    })
    .compileComponents();

    fixture = TestBed.createComponent(MediaComponent);
    component = fixture.componentInstance;
    router = TestBed.inject(Router) as jasmine.SpyObj<Router>;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should navigate to order when order button is clicked', () => {
    const media = {id: 1, price: 100, name: 'mock media',isAvailable: true, mediaType: 'Audio', description: 'mock description'};
    component.media = media

    component.order()

    expect(router.navigate).toHaveBeenCalledWith(['order', { media: JSON.stringify(media) }])
  })
});
