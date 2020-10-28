import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SituacionComponent } from './situacion.component';

describe('SituacionComponent', () => {
  let component: SituacionComponent;
  let fixture: ComponentFixture<SituacionComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [SituacionComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SituacionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
