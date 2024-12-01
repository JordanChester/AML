import { ComponentFixture, TestBed } from '@angular/core/testing';
import { LibraryComponent } from './library.component';
import { MediaService } from '../_services/media.service';
import { ActivatedRoute } from '@angular/router';
import { of } from 'rxjs';
import { Media } from '../_models/Media';
import {NavbarComponent} from "../navbar/navbar.component";
import {provideHttpClient} from "@angular/common/http";
import {MediaComponent} from "../media/media.component";

describe('LibraryComponent', () => {
  let component: LibraryComponent;
  let fixture: ComponentFixture<LibraryComponent>;
  let mediaServiceMock: jasmine.SpyObj<MediaService>;
  let activatedRouteMock: jasmine.SpyObj<ActivatedRoute>;

  beforeEach(async () => {
    mediaServiceMock = jasmine.createSpyObj('MediaService', ['searchMedia']);
    activatedRouteMock = jasmine.createSpyObj('ActivatedRoute', ['snapshot']);

    activatedRouteMock.snapshot = {
      paramMap: {
        get: jasmine.createSpy('get')
      }
    } as any;

    await TestBed.configureTestingModule({
      declarations: [LibraryComponent, NavbarComponent, MediaComponent],
      providers: [
        provideHttpClient(),
        { provide: MediaService, useValue: mediaServiceMock },
        { provide: ActivatedRoute, useValue: activatedRouteMock },
      ],
    }).compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(LibraryComponent);
    component = fixture.componentInstance;
  });

  describe('ngOnInit', () => {

    it('should call mediaService.searchMedia with the search parameter and update mediaList', () => {
      const mockMedia: Media[] = [
        { id: 3, name: 'mock name', price: 0, isAvailable: true, mediaType: 'Audio', description: 'mock description' }
      ];

      (mediaServiceMock.searchMedia as jasmine.Spy).and.returnValue(of(mockMedia));
      (activatedRouteMock.snapshot.paramMap.get as jasmine.Spy).and.returnValue('mockSearch');

      fixture.detectChanges();

      expect(mediaServiceMock.searchMedia).toHaveBeenCalledWith('mockSearch');
      expect(component.mediaList).toEqual(mockMedia);
    });
  });
});

