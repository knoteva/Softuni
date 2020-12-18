import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ViewFirmComponent } from './view-firm.component';

describe('ViewFirmComponent', () => {
  let component: ViewFirmComponent;
  let fixture: ComponentFixture<ViewFirmComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ViewFirmComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ViewFirmComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
