import { ComponentFixture, TestBed } from '@angular/core/testing';
import { OrderMediaComponent } from './order-media.component';
import { ActivatedRoute, Router } from '@angular/router';
import { of, throwError } from 'rxjs';
import { ReactiveFormsModule } from '@angular/forms';
import { RouterTestingModule } from '@angular/router/testing';
import { MediaService } from "../_services/media.service";
import { StorageService } from "../_services/storage.service";
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatNativeDateModule } from '@angular/material/core';
import {MatTab, MatTabGroup} from "@angular/material/tabs";
import {BrowserAnimationsModule} from "@angular/platform-browser/animations"; // Import MatNativeDateModule

describe('OrderMediaComponent', () => {
  let component: OrderMediaComponent;
  let fixture: ComponentFixture<OrderMediaComponent>;
  let mediaService: jasmine.SpyObj<MediaService>;
  let storageService: jasmine.SpyObj<StorageService>;
  let router: jasmine.SpyObj<Router>;

  beforeEach(async () => {
    const mediaServiceSpy = jasmine.createSpyObj('MediaService', ['borrowMedia']);
    const storageServiceSpy = jasmine.createSpyObj('StorageService', ['getUser']);
    const routerSpy = jasmine.createSpyObj('Router', ['navigate']);

    const activatedRouteSpy = jasmine.createSpyObj('ActivatedRoute', ['snapshot']);

    activatedRouteSpy.snapshot = {
      paramMap: {
        get: (key: string) => {
          if (key === 'media') {
            return JSON.stringify({ id: 1, price: 100 });
          }
          return null;
        },
      },
    } as any;

    await TestBed.configureTestingModule({
      declarations: [ OrderMediaComponent ],
      imports: [
        RouterTestingModule,
        ReactiveFormsModule,
        MatDatepickerModule,
        MatFormFieldModule,
        MatNativeDateModule,
        MatTabGroup,
        MatTab,
        BrowserAnimationsModule
      ],
      providers: [
        { provide: MediaService, useValue: mediaServiceSpy },
        { provide: StorageService, useValue: storageServiceSpy },
        { provide: Router, useValue: routerSpy },
        { provide: ActivatedRoute, useValue: activatedRouteSpy },
      ]
    }).compileComponents();

    fixture = TestBed.createComponent(OrderMediaComponent);
    component = fixture.componentInstance;
    mediaService = TestBed.inject(MediaService) as jasmine.SpyObj<MediaService>;
    storageService = TestBed.inject(StorageService) as jasmine.SpyObj<StorageService>;
    router = TestBed.inject(Router) as jasmine.SpyObj<Router>;
  });

  it('should create the component', () => {
    expect(component).toBeTruthy();
  });

  it('should call borrowMedia when confirm is called and navigate to account', () => {
    const mockMedia = { id: 1, price: 100 };
    const mockUser = { id: 123 };
    const activatedRouteSpy = TestBed.inject(ActivatedRoute) as jasmine.SpyObj<ActivatedRoute>;
    activatedRouteSpy.snapshot.paramMap.get = () => JSON.stringify(mockMedia);

    storageService.getUser.and.returnValue(mockUser);

    const startDate = new Date();
    const endDate = new Date();
    mediaService.borrowMedia.and.returnValue(of(true));

    fixture.detectChanges();

    component.confirm(startDate, endDate);

    expect(mediaService.borrowMedia).toHaveBeenCalledWith(mockUser.id, mockMedia.id, startDate, endDate);
    expect(router.navigate).toHaveBeenCalledWith(['account']);
  });

  it('should handle borrowMedia error gracefully', () => {
    const mockMedia = { id: 1, price: 100 };
    const mockUser = { id: 123 };
    const activatedRouteSpy = TestBed.inject(ActivatedRoute) as jasmine.SpyObj<ActivatedRoute>;
    activatedRouteSpy.snapshot.paramMap.get = () => JSON.stringify(mockMedia);

    storageService.getUser.and.returnValue(mockUser);

    const startDate = new Date();
    const endDate = new Date();
    const errorResponse = { error: { message: 'Error occurred!' } };
    mediaService.borrowMedia.and.returnValue(throwError(errorResponse));

    fixture.detectChanges();

    spyOn(console, 'log');
    component.confirm(startDate, endDate);

    expect(mediaService.borrowMedia).toHaveBeenCalledWith(mockUser.id, mockMedia.id, startDate, endDate);
    expect(console.log).toHaveBeenCalledWith('Error occurred!');
  });
});
