import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { MovFisicoExamplesComponent } from './mov-fisico-examples.component';

describe('MovFisicoExamplesComponent', () => {
  let component: MovFisicoExamplesComponent;
  let fixture: ComponentFixture<MovFisicoExamplesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MovFisicoExamplesComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MovFisicoExamplesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
