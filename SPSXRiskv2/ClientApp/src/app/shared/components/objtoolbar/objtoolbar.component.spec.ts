import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ObjtoolbarComponent } from './objtoolbar.component';

describe('ObjtoolbarComponent', () => {
  let component: ObjtoolbarComponent;
  let fixture: ComponentFixture<ObjtoolbarComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ObjtoolbarComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ObjtoolbarComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
