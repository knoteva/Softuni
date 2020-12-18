import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DeleteFirmComponent } from './delete-firm.component';

describe('DeleteFirmComponent', () => {
  let component: DeleteFirmComponent;
  let fixture: ComponentFixture<DeleteFirmComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DeleteFirmComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DeleteFirmComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
