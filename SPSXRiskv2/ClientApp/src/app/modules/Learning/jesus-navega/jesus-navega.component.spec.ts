import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { JesusNavegaComponent } from './jesus-navega.component';

describe('JesusNavegaComponent', () => {
  let component: JesusNavegaComponent;
  let fixture: ComponentFixture<JesusNavegaComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ JesusNavegaComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(JesusNavegaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
