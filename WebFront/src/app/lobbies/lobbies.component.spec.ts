import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { LobbiesComponent } from './lobbies.component';

describe('LobbiesComponent', () => {
  let component: LobbiesComponent;
  let fixture: ComponentFixture<LobbiesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ LobbiesComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(LobbiesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
