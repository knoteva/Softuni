import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { FirmsListComponent } from './firms-list.component';

describe('FirmsListComponent', () => {
  let component: FirmsListComponent;
  let fixture: ComponentFixture<FirmsListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ FirmsListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(FirmsListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
