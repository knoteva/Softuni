import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AddFirmComponent } from './add-firm.component';

describe('AddFirmComponent', () => {
  let component: AddFirmComponent;
  let fixture: ComponentFixture<AddFirmComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AddFirmComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AddFirmComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
