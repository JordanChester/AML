import { ComponentFixture, TestBed, fakeAsync, tick } from '@angular/core/testing';

import { AccountComponent } from './account.component';
import { provideHttpClient } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { NavbarComponent } from '../navbar/navbar.component';

fdescribe('AccountComponent', () => {
  let component: AccountComponent;
  let fixture: ComponentFixture<AccountComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [AccountComponent, NavbarComponent],
      imports: [FormsModule],
      providers: [provideHttpClient()]
    })
      .compileComponents();
    
    fixture = TestBed.createComponent(AccountComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should register edit details button click', fakeAsync(() => {
    spyOn(component, 'editClicked');
    let editButton = fixture.debugElement.nativeElement.querySelector('.edit');
    editButton.click();
    tick();

    expect(component.editClicked).toHaveBeenCalled();
  }));

  it('should register change password button click', fakeAsync(() => {
    spyOn(component, 'changePassClicked');
    let passButton = fixture.debugElement.nativeElement.querySelector('.pass');
    passButton.click();
    tick();

    expect(component.changePassClicked).toHaveBeenCalled();
  }));

  it('should register change branch button click', fakeAsync(() => {
    spyOn(component, 'changeBranchClicked');
    let branchButton = fixture.debugElement.nativeElement.querySelector('.branch');
    branchButton.click();
    tick();

    expect(component.changeBranchClicked).toHaveBeenCalled();
  }));

  it('should close password and branch when edit details is clicked', fakeAsync(() => {
    component.editMode = false;
    component.changePassword = true;
    component.changeBranch = true;

    component.editClicked();

    expect(component.changePassword && component.changeBranch).toBe(false);
  }));

  it('should close edit and branch when change password is clicked', fakeAsync(() => {
    component.editMode = true;
    component.changePassword = false;
    component.changeBranch = true;

    component.changePassClicked();

    expect(component.editMode && component.changeBranch).toBe(false);
  }));

  it('should close edit and password when change branch is clicked', fakeAsync(() => {
    component.editMode = true;
    component.changePassword = true;
    component.changeBranch = false;

    component.changeBranchClicked();

    expect(component.editMode && component.changePassword).toBe(false);
  }));

});
