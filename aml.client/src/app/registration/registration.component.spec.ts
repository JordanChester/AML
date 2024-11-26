import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RegistrationComponent } from './registration.component';
import { Branch } from '../_models/Branch';
import { BranchService } from '../_services/branch.service';
import { By } from '@angular/platform-browser';
import { HttpClient, HttpHandler, provideHttpClient } from '@angular/common/http';
import { NavbarComponent } from '../navbar/navbar.component';
import { FormsModule } from '@angular/forms';

describe('RegistrationComponent', () => {
  let component: RegistrationComponent;
  let fixture: ComponentFixture<RegistrationComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [RegistrationComponent, NavbarComponent],
      imports: [FormsModule],
      providers: [provideHttpClient()]
    })
    .compileComponents();

    fixture = TestBed.createComponent(RegistrationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should populate branches from service', () => {
    const branchService = fixture.debugElement.injector.get(BranchService);
    let branches = new Array<Branch>();
    branchService.getBranches().subscribe({
      next: data => {
        branches = data;
      }
    });

    expect(branches).toEqual(component.branches);
  });

  it('should show invalid when form empty', () => {
    expect(component.form.valid).toBeFalsy();
  });
});
