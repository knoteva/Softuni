import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { UpdateFirmComponent } from './update-firm.component';

describe('UpdateFirmComponent', () => {
  let component: UpdateFirmComponent;
  let fixture: ComponentFixture<UpdateFirmComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ UpdateFirmComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(UpdateFirmComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
